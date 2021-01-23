    public partial class Form1 : Form
    {
        ticket[] ticketFirst = new ticket[4];
        ticket[] ticketEcon = new ticket[6]; 
        
        public Form1()
        {
            InitializeComponent();
            ticketFirst = new ticket[4];
            ticketEcon = new ticket[6];  
        }
    
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int rand = random.Next(0, 4);
            if (ticketFirst[rand].getLastName = null)
            {
                ticketFirst[rand].setLastName = txbLastName.Text;
                ticketFirst[rand].setFirstName = txbFirstName.Text;
                ticketFirst[rand].setOrigin = txbOrigin.Text;
                ticketFirst[rand].setDestination = txbDestination.Text;
                ticketFirst[rand].setFlightNumber = txbFlightNumber.Text;
                ticketFirst[rand].setSeatNumber = txbSeatNumber.Text;
                ticketFirst[rand].setDate = txbDate.Text;
            }
            else
            {                
                MessageBox.Show("Seat Assignment Failed, try again.", "Seat Assignment");
            }
        }
    }
