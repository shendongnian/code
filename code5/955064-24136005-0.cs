     public class CustomMaskedBox : MaskedTextBox
    {
        public CustomMaskedBox()
        {
            this.MaskInputRejected += CustomMaskedBox_MaskInputRejected;
            this.Enter += CustomMaskedBox_Enter;
            this.Leave += CustomMaskedBox_Leave;
        }
        void CustomMaskedBox_Leave(object sender, EventArgs e)
        {
            if (this.MaskFull)
            {
                this.BackColor = Color.LightGreen;
            }
            else
            {
                this.Mask = "(00) 0000-0000";
                this.BackColor = Color.LightGreen;
            }
            if (!this.MaskCompleted)
            {
                this.BackColor = Color.LightCoral;
            }
        }
        void CustomMaskedBox_Enter(object sender, EventArgs e)
        {
            this.BackColor = Color.LightBlue;
        }
        void CustomMaskedBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (this.MaskFull)
            {
                this.Mask = "(00) 0000-00000";
                this.BackColor = Color.LightYellow;
            }
        }
    }
