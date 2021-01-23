    interface ITool {
        DoJob();
    }
    class Hammer : ITool { // impl details }
    interface IToolRepository {
        IEnumerable<ITool> GetTools();
    }
    class ToolsRepository : IToolRepository {
        IEnumerable<ITool> GetTools() {
            // return ITool implementations from this assembly using
            //any method you like, whether from database, web service, or reflection, etc ..
        }
    }
    static RepositoryFactory {
        IToolRepository CreateRepository() { // returns concrete repository };
    }
