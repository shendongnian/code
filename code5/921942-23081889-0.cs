         // add the litenal control - DIVs
         basketDiv.Controls.Add(new LiteralControl("<div class='item_bar'><div class='item_id'>" + id + "</div><div class='item_title'>" + name + "</div><div class='item_price'>" + cost + "</div>"));
        // create button and Add it to basketDiv
        Button button = new Button();
        button.Name = "Button1";
        // you can added other attribute here.
        button.Text = "New Button";
        button.Location = new Point(70,70);
        button.Size = new Size(100, 100);        
        basketDiv.Controls.Add(button);
         // close the parent Liternal "DIV class='item_bar'"
        basketDiv.Controls.Add(new LiteralControl("</div>"));
