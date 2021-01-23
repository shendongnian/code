    public class IndexViewModel : LayoutViewModel
    {
        public IndexViewModel(IEnumerable<StaffModel> staffModel)
        {
            _staffMembers = StaffModelMapperFactory.Map(staffModel);
        }
        private readonly List<PartialStaffViewModel> _staffMembers;
        public List<PartialStaffViewModel> StaffMembers {get {return _staffMembers;}}
    }
