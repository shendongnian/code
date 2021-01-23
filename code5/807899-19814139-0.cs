        if(attributes!=null)
        {
        for (int i = 0; i < attributes.Count; i++)
        {
          if(attributes[i]!=null)
           {
            for (int j = 0; j < attributes[i].Count; j++)
            {
                switch (attributes[i][j])
                {
                    case "Image":
                        images.Add(this.content.Load<Texture2D>(contents[i][j]));
                        fade.Add(new FadeAnimation());
                        break;
                    
                }
            }
        }
      }
    }
