    void MyClass::button1_Click() 
    {
        QList<MyObject> myobjectlist;
        MyObject selectedobject;
        foreach (const MyObject &o, myobjectlist) {
            if (o.property("Some name").isValid()) {
                selectedobject = o;
                break;        
            }
        }
    }
