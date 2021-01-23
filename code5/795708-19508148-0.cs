        for (int index = 0; index < this._routeItemList.Count; ++index)
        {
          if (index >= endIndex)
          {
            object bubbleSource = this.GetBubbleSource(index, out endIndex);
            if (!reRaised)
              args.Source = bubbleSource ?? source;
          }
