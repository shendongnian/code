    public partial class ChampionSelect : Form {
        public class ChampionSelectedEventArgs: EventArgs {
            public Image ChampionImage { get; set; }
            
            public ChampionSelectedEventArgs(Image championImage) {
                this.ChampionImage = championImage;
            }
        }
        
        public event EventHandler<ChampionSelectedEventArgs> ChampionSelected;
        
        public ChampionSelect() { }
        
        protected void onChampionSelected(Image im) {
            if(this.ChampionSelected != null)
                this.ChampionSelected(this, new ChampionSelectedEventArgs(im));
        }
        
        public void icon_slctAce_Click(object sender, EventArgs e) {
            onChampionSelected(Properties.Resources.Ace);
        }
    }
    
    public partial class Main : Form {
        private void pictureBox_championSelect_Click(object sender, EventArgs e) {
            ChampionSelect champSlct = new ChampionSelect());
            champSlct.ChampionSelected += this.championSelected;
            
            champSlct.Show();
        }
    
        private void championSelected(object sender, ChampionSelectedEventArgs e) {
            this.pictureBox_championSelect.Image = e.ChampionImage;
        }
    }
