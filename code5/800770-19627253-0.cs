     public EditContext(Item item)
    {
      Assert.ArgumentNotNull((object) item, "item");
      this._item = item;
      this._item.Editing.BeginEdit();
    }
