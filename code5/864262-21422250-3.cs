    public class JTokenWrapper : DynamicObject
    {
        public JTokenWrapper(JToken token)
        {
            if (token == null) throw new ArgumentNullException("token");
            this.Token = token;
        }
        public JToken Token { get; private set; }
        
        public override DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new JValueUnwrapperMetaObject(parameter, Token);
        }
        
        class JValueUnwrapperMetaObject : ProjectedDynamicMetaObjectWrapper<JToken>
        {
            public JValueUnwrapperMetaObject(Expression expression, JToken token)
                : base(expression, ExpressionSelector, token)
            {
            }
            
            private static Expression ExpressionSelector(Expression expression)
            {
                return LinqExpression.Property(
                    LinqExpression.Convert(expression, typeof(JTokenWrapper)),
                    "Token"
                );
            }
            
            public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
            {
                return UnwrappedValue(base.BindGetMember(binder));
            }
        
            public override DynamicMetaObject BindGetIndex(GetIndexBinder binder, DynamicMetaObject[] indexes)
            {
                return UnwrappedValue(base.BindGetIndex(binder, indexes));
            }
        
            private DynamicMetaObject UnwrappedValue(DynamicMetaObject getter)
            {
                var expr = GenerateUnwrapperExpression(getter.Expression);
                return new DynamicMetaObject(expr, getter.Restrictions, getter.Value);
            }
            
            private static readonly Dictionary<JTokenType, Func<Expression, Expression>> UnwrappedTypes = new Dictionary<JTokenType, Func<Expression, Expression>>
            {
                { JTokenType.Boolean,   UnwrapBoolean   },
                { JTokenType.String,    UnwrapString    },
                { JTokenType.Integer,   UnwrapInteger   },
            };
            
            private static Expression ExplicitConvert(Expression token, Type type)
            {
                return LinqExpression.Convert(
                    token,
                    type,
                    typeof(JToken).GetMethods().Where(m => m.Name == "op_Explicit").Single(m => m.ReturnType == type)
                );
            }
            
            private static Expression UnwrapBoolean(Expression token)
            {
                return ExplicitConvert(token, typeof(bool));
            }
            
            private static Expression UnwrapString(Expression token)
            {
                return ExplicitConvert(token, typeof(string));
            }
            
            private static Expression UnwrapInteger(Expression token)
            {
                // TODO: figure out the appropriate type
                return token;
            }
            
            private Expression GenerateUnwrapperExpression(Expression value)
            {
                var token = LinqExpression.Variable(typeof(JToken));
                var returnTarget = LinqExpression.Label(typeof(object));
                return LinqExpression.Block(
                    typeof(object),
                    new ParameterExpression[] { token },
                    LinqExpression.Assign(token, LinqExpression.Convert(value, typeof(JToken))),
                    LinqExpression.Switch(
                        LinqExpression.Property(token, "Type"),
                        UnwrappedTypes.Select(x =>
                            LinqExpression.SwitchCase(
                                LinqExpression.Return(returnTarget,
                                    LinqExpression.Convert(
                                        x.Value(token),
                                        typeof(object)
                                    )
                                ),
                                LinqExpression.Constant(x.Key)
                            )
                        ).ToArray()
                    ),
                    LinqExpression.Label(
                        returnTarget,
                        LinqExpression.New(
                            typeof(JTokenWrapper).GetConstructors().Single(),
                            LinqExpression.Convert(value, typeof(JToken))
                        )
                    )
                );
            }
        }
    }
