    namespace Sell_System
    {
        public partial class Form4 : Form
        {
           // Declaration of your controls....
           private TextBox dateContainer;
           private TextBox timeContainer;
           private Timer timer;
    
           public Form4()
           {
              // This is were the controls defined by the form designer will be initialized
              // using all the default values for their property
              InitializeComponent();
              // Now you do it manually for the controls added manually
              dateContainer = new TextBox();
              // At least define the position where the control should appear on the form surface
              dateContainer.Location = new Point(10, 10);
              dateContainer.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy", System.Globalization.CultureInfo.InvariantCulture);
    
              timeContainer = new TextBox();
              timeContainer.Location = new Point(30, 10);
              timeContainer.Text = DateTime.Now.ToString("h:mm tt", System.Globalization.CultureInfo.InvariantCulture);
              // To be shown the controls should be added to the Form controls collection    
              this.Controls.Add(dateContainer);
              this.Controls.Add(nameContainer);
              
              // The WinForm timer is just a component so it is enough to Initialize it
              timer = new System.Windows.Forms.Timer();             
              timer.Tick += new System.EventHandler(this.StartTimer);
              timer.Interval = 60000;
              timer.Start();
          }
    }
