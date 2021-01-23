        class ValueObj
        {
            //your fields were not public and you can not access them,
            //also public fields are not good so change them to property
            public int ID { get; set; }
            public float value { get; set; };
        }
