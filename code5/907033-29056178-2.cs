        protected void OnOpen (object sender, EventArgs e)
        {
            using(FileChooserDialog chooser =
                new FileChooserDialog(null,
                                      "Select document to open...",
                                      null,
                                      FileChooserAction.Open,
                                      "Open Selected File",
                                      ResponseType.Accept,
                                      "Discard & Return to Main Page",
                                      ResponseType.Cancel))
            {
                if (chooser.Run () == (int)ResponseType.Accept)
                {
                    System.IO.StreamReader file = System.IO.File.OpenText (chooser.Filename);
                    /* Copy the contents to editableTxtView   <- This is the Widget Name */
                    editableTxtView.Buffer.Text = file.ReadToEnd ();
                    /* If you want to read the file into explorer, thunar, Notepad, etc.,
                     * you'll have to research that yourself.  */
                    //Close file - - KEEP IT CLEAN - - & deAllocated memory!!
                    file.Close ();
                }
            }
        }
