    namespace FluentAssertions
    {
       public class SimpleIsNotDefaultEquivalencyStep : IEquivalencyStep
       {
            public bool CanHandle(EquivalencyValidationContext context, IEquivalencyAssertionOptions config)
            {
                return true;
            }
            public virtual bool Handle(EquivalencyValidationContext context, IEquivalencyValidator structuralEqualityValidator, IEquivalencyAssertionOptions config)
            {
                context.Subject.Should().NotBeDefault( context.Reason, context.ReasonArgs );
                return true;
            }
        }
        public static class FluentAssertionsDefaultnessExtensions
        {
            private static bool IsDefault( object value, bool orValueTypeDefault = false )
            {
                if( value == null )
                {
                    return true;
                }
                Type t = value.GetType();
                t = orValueTypeDefault ? Nullable.GetUnderlyingType( t ) ?? t : t;
                if( t.IsValueType )
                {
                    object defaultValue = Activator.CreateInstance( t );
                    return value.Equals( defaultValue );
                }
                else if( value is string )
                {
                    return string.IsNullOrWhiteSpace( value as string );
                }
                return false;
            }
            private static bool IsDefaultOrValueTypeDefault( object value )
            {
                return IsDefault( value, orValueTypeDefault: true );
            }
        
            public static AndConstraint<ObjectAssertions> NotBeDefault( this ObjectAssertions assertions, string because = "", params object[] reasonArgs )
            {
                Execute.Assertion
                    .BecauseOf( because, reasonArgs )
                    .ForCondition( !IsDefault( assertions.Subject ) )
                    .FailWith( "Expected {context:object} to not be default{reason}, but found {0}.", assertions.Subject );
                return new AndConstraint<ObjectAssertions>( assertions );
            }
            public static AndConstraint<StringAssertions> NotBeDefault( this StringAssertions assertions, string because = "", params object[] reasonArgs )
            {
                Execute.Assertion
                    .BecauseOf( because, reasonArgs )
                    .ForCondition( !IsDefault( assertions.Subject ) )
                    .FailWith( "Expected {context:object} to not be default{reason}, but found {0}.", assertions.Subject );
                return new AndConstraint<StringAssertions>( assertions );
            }
            public static AndConstraint<Numeric.NumericAssertions<T>> NotBeDefault<T>( this Numeric.NumericAssertions<T> assertions, string because = "", params object[] reasonArgs ) where T : struct
            {
                Execute.Assertion
                    .BecauseOf( because, reasonArgs )
                    .ForCondition( !IsDefault( assertions.Subject ) )
                    .FailWith( "Expected {context:object} to not be default{reason}, but found {0}.", assertions.Subject );
                return new AndConstraint<Numeric.NumericAssertions<T>>( assertions );
            }
            public static AndConstraint<BooleanAssertions> NotBeDefault( this BooleanAssertions assertions, string because = "", params object[] reasonArgs )
            {
                Execute.Assertion
                    .BecauseOf( because, reasonArgs )
                    .ForCondition( !IsDefault( assertions.Subject ) )
                    .FailWith( "Expected {context:object} to not be default{reason}, but found {0}.", assertions.Subject );
                return new AndConstraint<BooleanAssertions>( assertions );
            }
            public static AndConstraint<GuidAssertions> NotBeDefault( this GuidAssertions assertions, string because = "", params object[] reasonArgs )
            {
                Execute.Assertion
                    .BecauseOf( because, reasonArgs )
                    .ForCondition( !IsDefault( assertions.Subject ) )
                    .FailWith( "Expected {context:object} to not be default{reason}, but found {0}.", assertions.Subject );
                return new AndConstraint<GuidAssertions>( assertions );
            }
            public static void ShouldNotBeEquivalentToDefault<T>( this T subject, string because = "", params object[] reasonArgs )
            {
                ShouldNotBeEquivalentToDefault( subject, config => config, because, reasonArgs );
            }
            public static void ShouldNotBeEquivalentToDefault<T>( this T subject, 
                Func<EquivalencyAssertionOptions<T>, EquivalencyAssertionOptions<T>> config, string because = "", params object[] reasonArgs )
            {
                var context = new EquivalencyValidationContext
                {
                    Subject = subject,
                    Expectation = subject,
                    CompileTimeType = typeof( T ),
                    Reason = because,
                    ReasonArgs = reasonArgs
                };
                var validator = new EquivalencyValidator( 
                    config( EquivalencyAssertionOptions<T>.Default()
                        .Using<string>( ctx => ctx.Subject.Should().NotBeDefault() ).WhenTypeIs<string>() )
                        .WithStrictOrdering()
                        );
                validator.Steps.Remove( validator.Steps.Single( _ => typeof( TryConversionEquivalencyStep ) == _.GetType() ) );
                validator.Steps.Remove( validator.Steps.Single( _ => typeof( ReferenceEqualityEquivalencyStep ) == _.GetType() ) );
                validator.Steps.Remove( validator.Steps.Single( _ => typeof( SimpleEqualityEquivalencyStep ) == _.GetType() ) );
                validator.Steps.Add( new SimpleIsNotDefaultEquivalencyStep() );
            
                validator.AssertEquality( context );
            }
        }
    }
