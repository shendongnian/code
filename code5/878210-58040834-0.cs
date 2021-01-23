 C#
namespace CodeSample {    
    internal class ClassSample {
        //[?]| StartUp Object | Application start point;
        static void Main() {
           //[?]| return "One Hundred" |
           new (System.String)CodeSample.ClassSample.SampleMethod(2);
           //[?]| return "100.0" |
           new (System.Double)CodeSample.ClassSample.SampleMethod(4);
        }
        //[?]| Method | Used to perform operations;
        internal System.Object SampleMethod(Int MyParameter = 0) {
            switch(MyParameter) {
                case 1:
                    return 100;    
                case 2:
                    return "One Hundred";    
                case 3:
                    return true;    
                case 4:
                    return 100.0;
                default:
                    return null;
            }
        }
    }    
}
<hr>
> **System.Object** is used as a means to return any type;
NOTE: this is possible using the latest C Sharp | C&#35; version; code made with version 7.+
<!-- thanks for choosing DarkSystemCD -->
