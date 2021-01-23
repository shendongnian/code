    private: // <-- remember the colons (:)
         string c = "1";
         void expanded()
         {
            if(c = "1")
            {
               c = "2";
               ((Storyboard)this.Resources["_in"]).Begin(); //dono what this is
            }
            if(c == "2")
            {
               c = "1";
               ((Storyboard)this.Resources["_in1"])Begin(); //dono what this is
            }
         }
