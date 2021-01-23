    class MyItem : INPC
    {
        public string Name { get { ... } set { this.name = value; raisePropChanged("Name") } } ....
    }
    var item = new MyItem();
    collection.Add(item);
    item.Name = "John"; // notifies whoever listens on collection
    class MyItemWrapper
    {
        private MyItem theBrain;
        public string Name { get{return theBrain.Name;} set{theBrain.Name = value;}}
    }
    var item = new MyItem();
    var wrapped = new MyItemWrapper { theBrain = item };
    collectionOne.Add(item);
    collectionTwo.Add(wrapped);
    item.Name = "John";
    // notifies whoever listens on collectionOne
    // but whoever listens on collectionTwo will not get any notification
    // since "wrapper" does not notify about anything.
    // however, since wrapper forwards everything to 'brain':
    var name = wrapped.Name; // == "John"
