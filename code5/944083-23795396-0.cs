      /* Place this above the Page_Load event */
      Button[] btnArray;
      /* Call this method or something similar to instantiate the buttons */
       private void InstantiateBtns()
        {
            //Instatiate every possible button needed for some purpose
            btnArray = new Button[1000];
            for (int i = 0; i < btnArray.Length; i++)
            {
                btnArray[i] = new Button();
                // sets the attributes for the button control
                btnArray[i].ID = "ContactBtn" + i;
                btnArray[i].Width = 295;
                btnArray[i].Height = 50;
                btnArray[i].BorderStyle = BorderStyle.None;
                btnArray[i].CssClass = "contacts";
                btnArray[i].Click += new EventHandler(this.btnContactBtn_Click);
                btnArray[i].Attributes.Add("runat", "server");
            }
        } // end of InstantiateBtns()
      
      
