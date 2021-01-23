    //load image in your Form constructor
    public Form1()
    {
        InitializeComponent();
        //set your directory
        DirectoryInfo myDirectory = new DirectoryInfo(@"E:\MyImages");
        //set file type
        FileInfo[] allFiles = myDirectory.GetFiles("*.jpg");
        //loop through all files with that file type and add it to listBox
        foreach (FileInfo file in allFiles)
        {
                listBox1.Items.Add(file);
        }
    }
    //bind clicked image with picturebox
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Make selected item an image object
        Image clickedImage = Image.FromFile(@"E:\MyImages\" + listBox1.SelectedItem.ToString());
        pictureBox1.Image = clickedImage;
        pictureBox1.Height = clickedImage.Height;
        pictureBox1.Width = clickedImage.Width;
    }
