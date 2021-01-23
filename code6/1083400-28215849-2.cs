    public string BazGetScore(Transport.BazClass baz) {
         // Depending on the framework and class (all public getters/setters)?
         // your framework may allow for transparent serialization
         BazClass bazReal = bazFactory(baz);
         string score = bazReal.GetScore();
         return score;
     }
