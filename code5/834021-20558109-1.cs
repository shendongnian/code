    using System;
    
    public class Program{
       public static void Main(string[] args){
        string word = Console.ReadLine();
    
        if(word == "C#" || word == "VB"){
           Console.WriteLine("Oracle");//should actually be Microsoft
        }else if(word == "Android SDK"){
           Console.WriteLine("Google");
        }else if(word == "iOS" || word == "XCode"){
           Console.WriteLine("Apple");
        }else if(word.Split()[0] == "Java" && word.Split()[1] == "RedHat"){
           Console.WriteLine("Oracle");
        }else if(word == "Java"){
           Console.WriteLine("Sun Microsystems");
        }
      }
    }
