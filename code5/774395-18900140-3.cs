<!-- -->
    public class StaffModelMapperFactory
    {
        public static List<PartialStaffViewModel> Map(IEnumerable<StaffModel> staff)
        {
            return staff.Select(member => new PartialStaffViewModel
                {
                    FullName = string.Format("{0} {1} {2}", member.FirstName, member.MiddleInitial, member.LastName), 
                    CorporateTitle = member.CorporateTitle
                }).ToList();
        }
    }
