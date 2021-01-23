    struct Point { int x; int y; };
    
    struct MoveablePoint : public IMove {
        Point& point;
        MovablePoint(Point& point) : point(point) {}
        virtual void move(int l) { point.x += l; point.y += l; }
    };
