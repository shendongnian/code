    public partial class PlayerInfo : Form 
    { 
        public delegate void OnConfirmPlayer()
        public OnConfirmPlayer PlayerConfirmed;
    
        .....
    
        public void ConfirmPlayerInfo_Click(object sender, EventArgs e)
        {
            gm.P1Class = P1ClassChoice.Text;
            gm.P1Name = P1TextBox.Text;
            gm.P2Class = P2ClassChoice.Text;
            gm.P2Name = P2TextBox.Text;
            
            // Check is someone is interested to know this change
            // If you have a not null value then call the PlayerConfirmed method
            if (PlayerConfirmed != null) 
                PlayerConfirmed();
        }
    }
