    public static void Draw(SpriteBatch batch){
       for (i = 0; i < bottom.Count; i++)
       {
           bottom[i].Draw(batch);
       }
       //Gets the model from the IDisplay item, and then it's Y position, and orders
       //the sort layer(list) by that.
       sort = sort.OrderBy(o => o.getModel.Position.Y).ToList();
       for (i = 0; i < sort.Count; i++)
       {
           sort[i].Draw(batch);
       }
       for (i = 0; i < top.Count; i++)
       {
           top[i].Draw(batch);
       }
    }
