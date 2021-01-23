    using System;
    using System.Runtime.Serialization;
    using System.Collections.Generic;
    [Serializable]
    public class MyObject
    {
        [NonSerializeble]
        public MyObject child;
    }
    //this is the class that you are going to serialize
    [Serializable]
    public class ObjectsContrainer
    {
        private List<MyObject> allObjects;
        private List<serializationInfo> serializationInfos;
        //save info about the children in a way that we dont get any cycles
        [OnSerializing]
        private void OnSerializingStarted(StreamingContext context)
        {
            serializationInfos = new List<serializationInfo>();
            foreach (var obj in allObjects)
            {
                serializationInfo info = new serializationInfo {
                    parentIndex = allObjects.FindIndex(x => x == obj),
                    childIndex =  allObjects.FindIndex(x => x == obj.child)
                serializationInfos.Add(info);
            }
        }
        //restore info about the children
        [OnDeserialized]
        private void OnDeserialized(object o)
        {
            //restore connections
            foreach (var info in serializationInfos)
            {
                var parent = allObjects[info.parentIndex];
                parent.child = allObjects[info.childIndex];
            }
        }
        
        [Serializable]
        private struct serializationInfo
        {
            public int childIndex;
            public int parentIndex;
        }
    }
