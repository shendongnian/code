    public class CategoryEditPageModel
    {    
        CategoryModel Category { get; set;}
        //other data not directly related to category itself but needs to be visible on the page
        User CategoryOwner { get; set; }
    }
