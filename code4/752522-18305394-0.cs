    public int CalcUsing(IClass myClass, int x)
    {
         int result = myclass.Calculate(x);
         return result;
    }
    class SomeClass : IClass
    {
         //Implement the Calculate(int) method here
    }
    //Then the user of your class can do this with an instance of your form due to 
    //SomeClass inheriting the IClass type
    MainForm.CalcUsing(new SomeClass(), x);
