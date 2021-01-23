    public class GroupViewModel
    {
        public int GroupId{ get; set; }
    
        public Group Group {
            get { return new GroupRepository().GetById(GroupId); }
        }
        
        public object Subjects { get; set; }
    
        public IEnumerable<SelectListItem> SubjectItems
        {
            get
            {
                var items = new SelectList(new SubjectRepository().Get().ToList(), "Id", "Name");
                return items; 
            }
        }
    }
