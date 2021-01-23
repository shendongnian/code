    private int counter = 0;
    Random rnd = new Random();
    public void RandomPanel() {
      ++counter;
      if (counter > 2) {
        PbRow1_1.BackgroundImage = PbRow2_1.BackgroundImage;
        PbRow1_2.BackgroundImage = PbRow2_2.BackgroundImage;
        PbRow1_3.BackgroundImage = PbRow2_3.BackgroundImage;
        PbRow1_4.BackgroundImage = PbRow2_4.BackgroundImage;
      }
      if (counter > 1) {
        PbRow2_1.BackgroundImage = PbRow3_1.BackgroundImage;
        PbRow2_2.BackgroundImage = PbRow3_2.BackgroundImage;
        PbRow2_3.BackgroundImage = PbRow3_3.BackgroundImage;
        PbRow2_4.BackgroundImage = PbRow3_4.BackgroundImage;
      }
      int temp = rnd.Next(0, 4);
      Control[] boxes = new Control[] { PbRow3_1, PbRow3_2, PbRow3_3, PbRow3_4 };
      for (int i = 0; i < boxes.Length; ++i) {
        if (i == temp) {
          boxes[i].BackgroundImage = _2048Tiles.Properties.Resources.BlackTile;
        } else {
          boxes[i].BackgroundImage = _2048Tiles.Properties.Resources.GrayTile;
        }
      }
    }
