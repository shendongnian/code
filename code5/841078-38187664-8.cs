    public interface IRequestService {
        string GetFormValue(string key);
        HttpPostedFileBase GetFile(int index);
        //...other functionality you may need to abstract
    }
