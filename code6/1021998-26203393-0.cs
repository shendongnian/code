    ItemsSourc="{Binding Path=listTopicBinding}"
    DisplayMemberPath="Text"
    
    private ListTopicClass listTopicBinding = new ListTopicClass();
    public ListTopicBinding 
    {
       get { return listTopicBinding ; }
    }
