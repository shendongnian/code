     public void Consume(IDependency dependency)
     {    
          var intDependency = dependency as IInternalDependency;
          if(intDependency == null)
          {
             throw new InvalidOperationException();
          }
          intDependency.DoSomethingInternal();
     }
