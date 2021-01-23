    public abstract class DynamicDisplay
    {
       private Control c;
       public DynamicDisplay(Control display)
       {
           c = display;
       }
   
       //interprets the attribute visually and shows it in the control
       public abstract void ShowVal(double valToDisplay);
    }
    public class ProgBarDynamicDisplay : DynamicDisplay
    {
       private double max;
       public ProgBarDynamicDisplay(ProgressBar p, double nMax)
                : base( p)
       {
                max = nMax;
       }
     public override void ShowVal(double valToDisplay)
     {
          MessageBox.Show("Value : " + valToDisplay);
     }   
    }
