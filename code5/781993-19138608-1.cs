    private LambdaExpression GetLambda(Expression receiver, MemberInfo member) {
        LambdaExpression exp;
        if(!_mappings.TryGetValue(member, out exp)) {
            exp = _mappingLookup(member);
            if(null == exp) {
                var attr = (MapToExpressionAttribute) member.GetCustomAttributes(typeof(MapToExpressionAttribute), true).FirstOrDefault();
                // Added by me to deal with interfaces
                if (null == attr)
                {
                    if (null != receiver)
                    {
                        // member could be an interface's member, so check the receiver.object type
                        if (receiver.NodeType == ExpressionType.Constant)
                        {
                            var receiverType = ((ConstantExpression)receiver).Value.GetType();
                            var receiverMemberInfo = receiverType.GetMembers().Where(mi => mi.Name == member.Name).SingleOrDefault();
                            if (null != receiverMemberInfo)
                            {
                                attr = (MapToExpressionAttribute)receiverMemberInfo.GetCustomAttributes(typeof(MapToExpressionAttribute), true).FirstOrDefault();
                                member = receiverMemberInfo;
                            }
                        }
                    }
                }
                if(null != attr) {
                    exp = GetLambdaFromAttribute(receiver, member.DeclaringType, attr);
                }
            }
            _mappings.Add(member, exp);
        }
        return exp;
    }
