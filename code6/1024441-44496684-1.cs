    public class CustomAuthorize : AuthorizeAttribute {
    
    //Constructor
    public CustomAuthorize (params ProgramList[] programListTypes) {
    
                multipleProgramID= programListTypes;
            }
    
    private ProgramList[] multipleProgramID;
    
    }
