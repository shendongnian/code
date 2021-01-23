    public interface IRequestService {
        string GetFormValue(string key);
        HttpPostedFile GetFile(int index);
        //...other functionality you may need to abstract
    }
