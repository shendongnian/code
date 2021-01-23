    public class Page : BaseModel
    {
        //property declarations
        public override void OnSaveChanges<T>(T Obj)
        {
            base.OnSaveChanges<T>(Obj);
            Page model = Obj as Page;
            //Do something with the object.
            if (model.Parent_PageID == -1)
                model.Parent_PageID = null;
        }
    }
