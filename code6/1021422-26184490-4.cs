    public class CreateDefault<T,P>: Operator<T, P>, CreateOperator<T> where P: class, Processor<T> {
        public bool CanCreate(NameMatcher memberName, Tree<T> parameters) {
            return true;
        }
    
    public TypedValue Create(NameMatcher memberName, Tree<T> parameters) {
        var runtimeType = Processor.ApplicationUnderTest.FindType(memberName);
        return parameters.Branches.Count == 0
                     ? CreateWithoutParameters(runtimeType)
                     : CreateWithParameters(parameters, runtimeType);
    }
    
    static TypedValue CreateWithoutParameters(RuntimeType runtimeType) {
        try {
            return runtimeType.CreateInstance();
        }
        catch (System.Exception e) {
            throw new CreateException(runtimeType.Type, 0, e.InnerException ?? e);
        }
    }
    
    TypedValue CreateWithParameters(Tree<T> parameters, RuntimeType runtimeType) {
        RuntimeMember member = runtimeType.GetConstructor(parameters.Branches.Count);
        object[] parameterList = new ParameterList<T>(Processor).GetParameterList(TypedValue.Void, parameters, member);
            try {
                return member.Invoke(parameterList);
            }
            catch (System.Exception e) {
                throw new CreateException(runtimeType.Type, parameterList.Length, e.InnerException ?? e);
            }
        }
    }
