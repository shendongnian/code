    <#@ template debug="false" hostspecific="false" language="C#" #>
    <#@ assembly name="System.Core" #>
    <#@ import namespace="System" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ output extension=".cs" #>
    <#  const int maxParametersCount = 15; #>
    using System;
    using System.Linq.Expressions;
    
    public interface IInterceptable<T>
    {
    <# for(int parametersCount = 1; parametersCount <= maxParametersCount; parametersCount++) { 
       string parameters = String.Join(", ", Enumerable.Range(1, parametersCount).Select(i => "T" + i));         
    #>    IProxy<T> AddInterceptor<<#= parameters #>, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<<#= parameters #>, TResult>, <#= parameters #>, TResult> func);
    <#}#>
    }
