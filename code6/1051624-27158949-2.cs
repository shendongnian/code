    interface Visitor{
        visit(Node node);
    }
    class Node{
       //...
       
       void accept(Visitor v){
           //feel free to change visit order to viist children first
           v.visit(this);
           for(Node child : children){
              v.visit(child);
           }
       }
    }
