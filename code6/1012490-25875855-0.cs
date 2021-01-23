            int tmp = 0;
            int j = 20;
            var bookdp = new Book(); // DIFFERENT FORM
            List<Button> buttonsAdded = new List<Button>(books.Count);
            while (books.Count > tmp)
            {
                Button newButton = new Button()
                {
                    Text = "" + this.books[tmp],
                    Size = new System.Drawing.Size(200, 75),
                    Location = new System.Drawing.Point(20, j),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Name = "" + button1 + tmp
                };
                bookdp.Controls.Add(newButton);
                buttonsAdded.Add(buttonsAdded);
                tmp++;
                j += 80;
            }
            bookdp.Show();
            string text = buttonsAdded[0].Text;
            this.Hide();
