    public partial class PlayerInfo : Form 
    { 
        // define the delegate type (a parameterless method that returns nothing)
        public delegate void OnConfirmPlayer();
        // declare a public variable of that delegate type
        public OnConfirmPlayer PlayerConfirmed;
    
        .....
    
        public void ConfirmPlayerInfo_Click(object sender, EventArgs e)
        {
            gm.P1Class = P1ClassChoice.Text;
            gm.P1Name = P1TextBox.Text;
            gm.P2Class = P2ClassChoice.Text;
            gm.P2Name = P2TextBox.Text;
            
            // Check is someone is interested to be informed of this change
            // If someone assign a value to the public delegate variable then
            // you have to call that method to let the subscriber know 
            if (PlayerConfirmed != null) 
                PlayerConfirmed();
        }
    }
