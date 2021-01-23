    class MemberModel<TMember> where TMember : Member
    {
        public List<TMember> Team = new List<TMember>();
    
        public void IncreaseAge()
        {
            // Would like this to modify the Treemember
            Team[0].Age++;
        }
    }
    
    class TreeMemberModel : MemberModel<TreeMember>
    {
        public void UpdateName(string newName)
        {
    
        }
    }
