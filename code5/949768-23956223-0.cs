    public class MyClass{
    private readonly object internalLock= new object();
    
    ...
    public YourMethod(){
    ...
        \\Make a request and return new data (if any)
        lock(internalLock){
            foreach (var item in Lists)
            { 
                 \\Store new data
            }
        }
    ...
    }
