    public abstract class BaseClass
    {
        public List<ItemPointer> ItemPointers = new List<ItemPointer>();
        public abstract void Run(int index);
    }
    public class ItemPointer
    {
        public int Index { get; set; }
        public string ClassType { get; set; }
        public string UIDescription { get; set; }
    }
    
    
    public class Class1 : BaseClass
    {
        public Class1()
        {
            ItemPointers.Add(new ItemPointer { Index = 0, ClassType = this.GetType().Name,  UIDescription = "MethodA Description" });
            ItemPointers.Add(new ItemPointer { Index = 1, ClassType = this.GetType().Name,  UIDescription = "MethodB Description" });
        }
        public override void Run(int index)
        {            
            if (index == 0)
            {
                MethodA();
            }
            else if (index == 1)
            {
                MethodB();
            }
        }
        private void MethodA()
        {
            //do stuff
        }
        private void MethodB()
        {
            //do stuff
        }
    }
    public class UIForm
    {
        private List<BaseClass> _baseClasses;
 
        //Formload events load all baseclass types (including plugins via reflection during form init etc. Then call loadUIitems
        private void LoadUIItems()
        {
            foreach (BaseClass bc in _baseClasses)
            {
                foreach (var p in bc.ItemPointers)
                {
                    ToolStripMenuItem t = new ToolStripMenuItem(p.UIDescription);
                    t.Click += new EventHandler(WorkerMenu_Click);
                    t.Tag = p;
                    actionsToolStripMenuItem.DropDownItems.Add(t);  
                }
            }
        }
        void WorkerMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem t = (ToolStripMenuItem)sender;
            ItemPointer p = (ItemPointer)t.Tag;
            foreach (BaseClass bc in _baseClasses)
            {
                if (bc.GetType().Name == p.ClassType)
                {
                    bc.Run(p.Index);
                }
            }
        }
    }
