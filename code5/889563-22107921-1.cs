    class Something {
        public static function getInstance() {
            return new static();
        }
    }
    class Other extends Something {
        
    }
