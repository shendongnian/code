    message templateWrapper {
        repeated template items = 1;
    }
    message template {
        optional string name = 1;
        optional tempClass contour = 2;
        // ...
    }
    message tempClass {
        // ...
    }
