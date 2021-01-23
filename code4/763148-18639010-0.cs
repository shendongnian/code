    protected void Page_Load(System.Object sender, System.EventArgs e) {
        if (!Page.IsPostBack) {
            LoadImage();
        }
    }
    private void LoadImage(){
        Image1.ImageUrl = LoadURLFromDatabase(params);
        Image1.Width = (int)(image.Width * ratio);
        Image1.Height = (int)(image.Height * ratio);
    }
