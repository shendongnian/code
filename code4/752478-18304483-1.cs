    using System;
    using People
    namespace People {
        class Person {
            boolean male = false;
            int age = 17;
            public override String toString() {
                 return "Gender: " + (male ? "Male : "Female") + "\tAge: " + age;
            }
        }
    }
