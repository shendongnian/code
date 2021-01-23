    //Your form constructor
    public Form1(){
       InitializeComponent();
       originalImage = pictureBox.Image;
    }
    Image originalImage;
    private void greyscalePicture_Click(object sender, EventArgs e) {
     Image img = originalImage;// Not pictureBox.Image
     //...
    }
    private void sepiaPicture_Click(object sender, EventArgs e) {
     Image img = originalImage;// Not pictureBox.Image
     //...
    }
