    public class Kettle : ISwitchable
    {
         private IPowerSwitch Power;
         private IHeatingElement Heat;
         public Kettle()
         {
            Power = new PowerSwitch();
            Heat = new HeatingElement();
         }
    
         public void SwitchOn()
         {
             Power.SwitchOn();
             Heat.SwitchOn();
         }
         // And so on.
    }
    public class PowerSwitch : IPowerSwitch {}
    public class HeatingElement : IHeatingElement {}
