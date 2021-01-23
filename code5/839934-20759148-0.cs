        public MemberDetails(int id)
                {
                    InitializeComponent();
                    this.membersTableAdapter.Fill(this.membershipDataSet.Members);
                    // navigate to item 
                    for (int i = 0; i < id; i++)
                    {
                        this.membersBindingNavigator.MoveNextItem.PerformClick();
                    }
                }
