    public class YourClass {
       
        public static void main(String[] args) throws IOException {
        
            ProcessBuilder  yourProcess = new ProcessBuilder(); 
            Process process = yourProcess.start();//Creates a new object containing your process
            //Your insert SQL stuff...
            try {
                process.waitFor();//Waits until the process finish
            } catch (InterruptedException ex) {
                System.out.println("The process finished unexpectly");;
            }
            //Your delete SQL stuff...
        }
    }
