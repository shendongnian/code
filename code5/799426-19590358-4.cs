    flowLayoutPanel1.AutoScroll = true;
    for (int i = 0; i < 100; i++) {
       new BookPanel {
                    Parent = flowLayoutPanel1, 
                    Width = 150, 
                    Height = 200,
                    BorderStyle = BorderStyle.FixedSingle,
                    BookCover = yourImageList[i]
        }.BuyBook += buyBook;
    }
    private void buyBook(object sender, EventArgs e){
       BookPanel book = sender as BookPanel;
       //your code goes here ....
    }
