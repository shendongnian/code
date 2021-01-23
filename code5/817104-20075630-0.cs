     public class DAL.Repository<poco> {
     
        //methods for CRUD, get List, search whatever you see as right
        // eg ...add error handling....
        void add(poco p){
           context.attach(p);
        ... 
     }
    //  The domain/core model layer would have much of the object based business logic
     public class CORE.PocoXYZ {
        //all the get sets and methods required to manipulate the object
     }
    // And your Unit of Work Class
    Public class DAL.UoW{
        context.savechanges();
    }
    So i would suggest you perform object level Data storage in the DAL. But do all teh object manipulation in the core.  The DAL would control the save in a UoW class that managed all Repositories.
