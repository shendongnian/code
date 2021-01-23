    //Use this custom PictureBox for convenience
    public class AnimatedPictureBox : PictureBox {
      List<string> imageFilenames;
      Timer t = new Timer();
      public AnimatedPictureBox(){
        AnimateRate = 100; //It's up to you, the smaller, the faster.
        t.Tick += Tick_Animate;      
      }
      public int AnimateRate {
        get { return t.Interval; } 
        set { t.Interval = value;}
      }
      public void Animate(List<string> imageFilenames){
        this.imageFilenames = imageFilenames;
        t.Start();
      }
      public void StopAnimate(){
        t.Stop();
        i = 0;
      }
      int i;
      private void Tick_Animate(object sender, EventArgs e){
        if(imageFilenames == null) return;
        Load(imageFilenames[i]);
        i = (i+1)%imageFilenames.Count;
      }
    }
    //Now use the AnimatedPictureBox instead of the PictureBox
    pbs = new AnimatedPictureBox[8];
    //Animate all the PictureBoxes
    for(int i = 0; i < file_array.Length; i++){
      pbs[i].Animate(file_array[i]);
    }
