    public partial class MyForm: Form
    {
          
         IFunctionIntegrator integrator;
         public MyForm() {...}
         public MyForm(IFunctionIntegrator integrator)
             :this()
         {
              this.integrator = integrator;
         }
         public double IntegrateFunction(Func<double, double> function, double lowerLimit, double upperLimit)
         {
             return this.integrator.Integrate(function, lowerLimit, upperLimit);
         }
    }
