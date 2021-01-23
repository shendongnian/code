    private void Img_BG_process_Click(object sender, EventArgs e)
            {
                int rows = 5;//No of Rows as per Desire
                int columns = 6;//No of columns as per Desire
                var imgarray = new Image[rows, columns];//Create Image Array of Size Rows X Colums
                var img = image1;//Get Image from anywhere, From File Or Using Dialogbox used previously
                int height = img.Height;
                int width = img.Width;//Get image Height & Width of Input Image
                int one_img_h = height / rows;
                int one_img_w = width / columns;//You need Rows x Columns, So get 1/rows Height, 1/columns width of original Image
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        imgarray[i, j] = new Bitmap(one_img_w, one_img_h);//generating new bitmap
                        var graphics = Graphics.FromImage(imgarray[i, j]);
                        graphics.DrawImage(img, new Rectangle(0, 0, one_img_w, one_img_h), new Rectangle(j * one_img_w, i * one_img_h, one_img_w, one_img_h), GraphicsUnit.Pixel);//Generating Splitted Pieces of Image
                        graphics.Dispose();
                    }
                }
    //Image Is spitted You can use it by getting image from **imgarray[Rows, Columns]**
    //Or You can Save it by using Following Code
    
                var destinationFolderName = "";//Define a saving path
                FolderBrowserDialog FolderBrowserDialog1 = new FolderBrowserDialog();
                DialogResult result = FolderBrowserDialog1.ShowDialog();//Get folder Path Where splitted Image Saved
                if (result == DialogResult.OK)
                {
                    destinationFolderName = FolderBrowserDialog1.SelectedPath;
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            imgarray[i, j].Save(@"" + destinationFolderName + "/Image_" + i + "_" + j + ".jpg");//Save every image in Array [row][column] on local Path
                        }
                    }
                }
            }
