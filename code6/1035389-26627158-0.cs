      using System.IO;
      //..
      // load whereever you like
      // e.g. in the From.Load event or after InitializeComponent();
      var images = Directory.GetFiles(yourImageFolder, "*.jpg");
      foreach (string file in images)
      {
          imageList1.Images.Add(file, new Bitmap(file));
          comboBox1.Items.Add(new FileInfo(file));
      }
      comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
      comboBox1.DrawItem += comboBox1_DrawItem;
      comboBox1.ItemHeight = imageList1.ImageSize.Height;
      void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
      {
         FileInfo FI = (FileInfo)comboBox1.Items[e.Index];
         e.Graphics.DrawImage(imageList1.Images[FI.FullName], e.Bounds.Location);
         e.Graphics.DrawString(FI.Name, Font, Brushes.Black,
                e.Bounds.Left + imageList1.ImageSize.Height + 3, e.Bounds.Top + 4);
      }
