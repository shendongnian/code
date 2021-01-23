public void SomeOperationToGuard(int aParam, SomeType anotherParam)
{
   // you can pass the params to the work method using closure
   this.TheGuard.Execute(() => TheMethodThatDoesTheWork(aParam, anotherParam);
}
private void TheMethodThatDoesTheWork(int aParam, SomeType anotherParam) {}
