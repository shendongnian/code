    internal static class FactoryHelper {
        // Note that your method is not using instance variables of the class,
        // making it an ideal candidate for making a static helper method.
        public static void FactoryFaulted(object sender, EventArgs e) {
            ChannelFactory factory = (ChannelFactory)sender;
            try {
                factory.Close();
            } catch {
                factory.Abort();
            }
        }
    }
