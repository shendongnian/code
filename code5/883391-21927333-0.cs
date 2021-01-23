    private PictureBox getPictureBoxByName(string name)
    {
        foreach(object p in this.Controls ){
            if( p.GetType() == typeof(PictureBox) )
                if( ((PictureBox)p).Name == name )
                    return (PictureBox)p;
        }
        return new PictureBox(); //OR return null;
    }
